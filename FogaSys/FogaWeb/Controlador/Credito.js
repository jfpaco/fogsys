/// <reference path="../Scripts/jquery-1.7.1.js" />
/// <reference path="../Scripts/jquery-1.7.1.min.js" />
$(document).ready(function () {
    $("#tabs").tabs();

    // Llenado de Combos
    $('#cboEdoDfisPfis').autocompletaMunicipio();

    $('#cboEdoNot').autocompletaMunicipio();

    $('#cboEdoDparPfis').autocompletaMunicipio();

  
});