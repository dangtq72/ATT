// ---------------------------------------------     SESSION STORAGE     -----------------------------------------
function initAllSearchingData(currentKeySearch, currentOptionFilter, initOrderBySearchingCallback, setKeySearchCallback, findDataCallback, container) {
    window.__seasionstorage_keySearch = currentKeySearch;
    window.__seasionstorage_optionFilter = currentOptionFilter;

    var isDataPostBack = false;
    if (sessionStorage.getItem(window.__seasionstorage_lastLocationPath) !== null) {
        if (sessionStorage.getItem(window.__seasionstorage_lastLocationPath) !== window.location.pathname
            && sessionStorage.getItem(window.__seasionstorage_keySearch) !== null) {
            isDataPostBack = true;
        }
    }
    sessionStorage.setItem(window.__seasionstorage_lastLocationPath, window.location.pathname);
    if (isDataPostBack) {
        window.keySearch = sessionStorage.getItem(window.__seasionstorage_keySearch);
        window.optionFilter = sessionStorage.getItem(window.__seasionstorage_optionFilter);
        updateOptionFilterFromSessionStorage();
        updateOrderBySearching(container);
        findDataCallback(-1, 0);
    } else {
        initOrderBySearchingCallback();
        window.pageNumber = 1;
        window.recordPerPage = 10;
        updateFilterOption();
        setKeySearchCallback();
    }

    initSessionStorage();
    //bindColumnSortWithSearching(findDataCallback, container);
    //ChangeIConSortWhenSortColumns(container);
}

function pageContainDataOfSearching() {
    return location.href.indexOf("_searching_") !== -1;
}

function initSessionStorage() {
    if (sessionStorage.getItem(window.__seasionstorage_keySearch) === null) {
        sessionStorage.setItem(window.__seasionstorage_keySearch, window.keySearch);
        sessionStorage.setItem(window.__seasionstorage_optionFilter, optionFilter);
    }
}

function setOrderBySearching(container) {
    if (typeof container !== "undefined" && container !== null) {
        window.colSort = $(container).find("#colSorted").val();
        window.sortType = $(container).find("#SortType").val();
        window.optionSorting = validOptionSorting($(container).find("#OptionSorting").val());
    } else {
        window.colSort = $("#colSorted").val();
        window.sortType = $("#SortType").val();
        window.optionSorting = validOptionSorting($("#OptionSorting").val());
    }
}

function updateFilterOption() {
    window.optionFilter = window.colSort + "|" + window.sortType + "|" + validOptionSorting(window.optionSorting) + "|" + window.pageNumber + "|" + window.recordPerPage;
    return optionFilter;
}

function updateOrderBySearching(container) {
    if (typeof container !== "undefined" && container !== null) {
        $(container).find("#colSorted").val(window.colSort);
        $(container).find("#SortType").val(window.sortType);
        $(container).find("#OptionSorting").val(validOptionSorting(window.optionSorting));
    } else {
        $("#colSorted").val(window.colSort);
        $("#SortType").val(window.sortType);
        $("#OptionSorting").val(validOptionSorting(window.optionSorting));
    }
}

function getFilterOptionWhenExportDataToFile() {
    return window.colSort + "|" + window.sortType + "|" + validOptionSorting(window.optionSorting) + "|" + 1 + "|" + 0;
}

function enterKeyPress(e, elementHandle) {
    try {
        var code = e.keyCode || e.which;
        if (code === 13) {
            document.getElementById(elementHandle).click();
        }
    } catch (e) {
        console.log(e);
    }
}

function bindColumnSortWithSearching(callback, container) {
    if (typeof container !== "undefined" && container !== null) {
        $(container).find("th[data-sort]").on("click", function () {
            SortByCol(this, container);
            callback(1, 0);
        });
    } else {
        $("th[data-sort]").on("click", function () {
            SortByCol(this);
            callback(1, 0);
        });
    }
}

function SortByCol(el, container) {
    try {
        var value = $(el).attr("id");
        var currentOptionSorting = validOptionSorting($(el).attr("data-sortoption"));
        var currentColSorted, currentSortedType;

        if (typeof container !== "undefined" && container !== null) {
            currentColSorted = $(container).find("#colSorted").val();
            currentSortedType = $(container).find("#SortType").val();

            if (currentColSorted === value) {
                if (currentSortedType.toUpperCase() === "ASC") {
                    $(container).find("#SortType").val("DESC");
                }
                else {
                    $(container).find("#SortType").val("ASC");
                }
            }
            else {
                $(container).find("#colSorted").val(value);
                $(container).find("#SortType").val("ASC");
            }
            $(container).find('#OptionSorting').val(currentOptionSorting);
        } else {
            currentColSorted = $("#colSorted").val();
            currentSortedType = $("#SortType").val();

            if (currentColSorted === value) {
                if (currentSortedType.toUpperCase() === "ASC") {
                    $("#SortType").val("DESC");
                }
                else {
                    $("#SortType").val("ASC");
                }
            }
            else {
                $("#colSorted").val(value);
                $("#SortType").val("ASC");
            }
            $('#OptionSorting').val(currentOptionSorting);
        }
    } catch (e) {
        console.info(e.toString());
    }
}

function ChangeIConSortWhenSortColumns(container) {
    try {
        var orderBy, orderType, colText, text;
        if (typeof container !== "undefined" && container !== null) {
            orderBy = $(container).find("#colSorted").val();
            orderType = $(container).find("#SortType").val();
            colText = $(container).find("#" + orderBy).text().replace(" ▼", "").replace(" ▲", "");
            text = orderType === "DESC" ? colText + " ▼" : colText + " ▲";
            $(container).find("#" + orderBy).text(text);
        } else {
            orderBy = $("#colSorted").val();
            orderType = $("#SortType").val();
            colText = $("#" + orderBy).text().replace(" ▼", "").replace(" ▲", "");
            text = orderType === "DESC" ? colText + " ▼" : colText + " ▲";
            $("#" + orderBy).text(text);
        }
    }
    catch (e) {
        console.info(e.toString());
    }
}

function reinitSearchingConditions(currentKeySearch, currentOptionFilter, pageNumber, isSearching) {
    window.__seasionstorage_keySearch = currentKeySearch;
    window.__seasionstorage_optionFilter = currentOptionFilter;
    window.keySearch = sessionStorage.getItem(window.__seasionstorage_keySearch);
    window.optionFilter = sessionStorage.getItem(window.__seasionstorage_optionFilter);
    window.isSearching = isSearching;
    window.pageNumber = pageNumber;
    if (isSearching === 1) {
        window.pageNumber = 1;
    }
    if (pageNumber === -1) {
        updateOptionFilterFromSessionStorage();
    }
}

function updateOptionFilterFromSessionStorage() {
    window.arrOptionFilter = window.optionFilter.split('|');
    window.colSort = arrOptionFilter[0];
    window.sortType = arrOptionFilter[1];
    window.optionSorting = validOptionSorting(arrOptionFilter[2]);
    window.pageNumber = arrOptionFilter[3];
    window.recordPerPage = arrOptionFilter[4];
}

function validOptionSorting(optionSorting) {
    if (typeof optionSorting === "undefined" || optionSorting === null) {
        optionSorting = "";
    }
    return optionSorting;
}

function updateSearchingConditions(setKeySearchCallback, container) {
    setOrderBySearching(container);
    //if (idDivNumberRecordOnPage != null && idDivNumberRecordOnPage !== '') {
    //    window.recordPerPage = $("#" + idDivNumberRecordOnPage).val();
    //}
    setKeySearchCallback();
    sessionStorage.setItem(__seasionstorage_keySearch, keySearch);
    updateFilterOption();
    sessionStorage.setItem(__seasionstorage_optionFilter, optionFilter);
}