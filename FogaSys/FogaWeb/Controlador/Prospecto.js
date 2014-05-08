/// <reference path="../Scripts/jquery-1.7.1.js" />
/// <reference path="../Scripts/jquery-1.7.1.min.js" />
function qs(key) {
    key = key.replace(/[*+?^$.\[\]{}()|\\\/]/g, "\\$&"); // escape RegEx meta chars
    var match = location.search.match(new RegExp("[?&]" + key + "=([^&]+)(&|$)"));
    return match && decodeURIComponent(match[1].replace(/\+/g, " "));
}

function cambiaTitulos(opcion) {
    if (opcion == "F") {
        $("#lblTitDomPar").text('Domicilio Particular');
        $("#lblTitDatPer").text('Datos Personales');
    } else if (opcion == "M") {
        $("#lblTitDomPar").text('Domicilio Particular del Representante Legal');
        $("#lblTitDatPer").text('Datos Personales del Representante Legal');
    }
}

function activaValidacion(valor) {
    $(".moral").each(function () {
        var control = this.id;        
        if(valor == "false")
            document.getElementById(control).enabled = false;
        if(valor == "true")
            document.getElementById(control).enabled = true;
    });
}

function validaPorcentaje(oScr, args) {
    var porcentajeTotal = 0;
    $(".porcentaje").each(function () {
        porcentajeTotal += parseInt($(this).val());
        $(this).text = $(this).val();
    })

    if (porcentajeTotal == 100) {
        args.IsValid = true;
    } else {
        args.IsValid = false;
    }
}

function getFormulario() {
    var formulario = $("#rdoTipoPersona input[type='radio']:checked").val();
    if (formulario == "F") {
        $(".frmAmbos").show();
        $(".frmMoral").hide();
        activaValidacion("false");
        cambiaTitulos("F");
    } else if (formulario == "M") {
        $(".frmAmbos").show();
        $(".frmMoral").show();
        cambiaTitulos("M");
        activaValidacion("true");
    } else {
        $(".frmAmbos").hide();
        $(".frmMoral").hide();
        cambiaTitulos("F");
    }
}

$(document).ready(function () {

    if (qs("tip") == "nuevo") {
        $(".titForm h1").prepend("Nuevo ");
    }

    if (qs("tip") == "modificar") {
        $(".titForm h1").prepend("Modificar ");
    }

    getFormulario();

    $("input[type='radio']").on("change", function () {
        getFormulario();
    });
     
    // Llenado de Combos
    $('#cboEdoDfisPfis').autocompletaMunicipio();

    $('#cboEdoNot').autocompletaMunicipio();

    $('#cboEdoDparPfis').autocompletaMunicipio();

    //Fechas

    $("#txtFaltaSat").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });

    $("#txtFechaNacPfis").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });

    $("#txtFescPub").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });

    $("#txtFescRepleg").datepicker({
        showOn: "button",
        changeYear: true,
        buttonImage: "Imagenes/cal.png",
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy'
    });

    $(".porcentaje").live('focusout', function (event) {
        var porcentajeTotal = 0;
        $(".porcentaje").each(function () {
            porcentajeTotal += parseInt($(this).val());
            $(this).text = $(this).val();
        })

        if (porcentajeTotal > 100) {
            alert("Verifique sus porcentajes no deben de pasar de 100%");
            $(this).val("");
            $(this).focus();
            return false;
        }
    });        
    
});