/// <reference path="../Scripts/jquery-1.7.1.min.js" />
/// <reference path="../Scripts/jquery-ui-1.10.4.custom.min.js" />
$(document).ready(function () {
    
    $("#txtAntigNego").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });

    $("#txtLocalNegoVigen").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });
    
    $("#txtSegTipoDescrp").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });

});