function test3() {
    var dd = $('#ddlPlayer-2'), posteElement = $('#ddlPlayer-1');
    var currentIndexP = posteElement.get(0).selectedIndex, currentIndexD = dd.get(0).selectedIndex;
    if (currentIndexP == currentIndexD) dd.find('option').eq(currentIndexD).remove();
}