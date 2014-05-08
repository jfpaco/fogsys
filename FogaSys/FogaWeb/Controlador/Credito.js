/// <reference path="../Scripts/jquery-1.7.1.js" />
/// <reference path="../Scripts/jquery-1.7.1.min.js" />
$(document).ready(function () {
    $("#tabs").tabs();

    // Llenado de Combos
    $('#cboEdoDfisPfis').autocompletaMunicipio();

    $('#cboEdoNot').autocompletaMunicipio();

    $('#cboEdoDparPfis').autocompletaMunicipio();
    
    $('#txtMontoSolicit').live('focusout', function (event) {
        var montoMax = $('.lblTcredFogaMontoMax').text();
        montoMax = montoMax.replace(",", "");
        montoMax = parseFloat(montoMax.replace("$", ""));
        var montoMin = $('.lblDescMontoMin').text();
        montoMin = montoMin.replace(",", "");
        montoMin = parseFloat(montoMin.replace("$", ""));

        var montoActual = parseFloat($(this).val());

        alert("Monto minimo=" + montoMin + "  Mont maximo= " + montoMax + " MontoActual= " + montoActual);
        if (montoActual < montoMin) {
            alert("Monto menor al del credito solicitado");            
            return false;
        }
        if (montoActual > montoMax) {
            alert("Monto mayor al del credito solicitado");
            return false;
        }
    });

    $('#txtPlazoMeses').live('focusout', function (event) {
        var montoMax = $('.lblDescPlazoMax').text();
        montoMax = parseFloat(montoMax.replace("$", ""));
        var montoMin = $('.lblDescPlazoMin').text();
        montoMin = parseFloat(montoMin.replace("$", ""));

        var montoActual = parseFloat($(this).val());

        //alert("Monto minimo=" + montoMin + "  Mont maximo= " + montoMax + " MontoActual= " + montoActual);
        if (montoActual < montoMin) {
            alert("Plazo menor al del credito solicitado");
            return false;
        }
        if (montoActual > montoMax) {
            alert("Plazo mayor al del credito solicitado");
            return false;
        }
    });

});