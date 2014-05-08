/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery-1.7.1.min.js" />
function llenaMunicipio(objHddDescMun, objMuni, objHddIdMun, objInicio) {        
        var cadena = objHddDescMun.val();
        cadena = cadena.split(",");
        //alert(cadena);
        removeOptions(objMuni);

        if (cadena[0] != "") {
            for (var i = 0; i < cadena.length; i++) {
                var valor = cadena[i++];
                var texto = cadena[i];
                objMuni.append('<option value="' + texto + '">' + valor + '</option>');
            }
        }
        if (objInicio == "si")
            objMuni.val(objHddIdMun.val());
        else {
            if (objHddIdMun.val() != "")
                objMuni.val(objHddIdMun.val());
        }
}

function testAjax(idEdo) {
    return $.ajax({
        type: "POST",
        url: "Catalogos.aspx/ChecaMunicipio",
        data: "{'idEdo':'" + idEdo + "'}",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (Result) {
            $.each(Result.d, function (key, value) {
                var caca = "";
                if (caca == "")
                    caca = value.MuniNombre + "," + value.IdMuni;
                else
                    caca = caca + "," + value.MuniNombre + "," + value.IdMuni;
            });            
        },
        error: function (xhr, status, error) {
            alert(xhr + "  " + status + "   " + error);
        }
    });
}

function llenaMunicipioInicial(idEdo) {
    
        
}

function removeOptions(selectbox) {
    selectbox.html("");    
}

(function ($) {

    // Llenado de Combos    
    $.fn.autocompletaMunicipio = function ()
    {
                        
        $(this).each(function () {
                            
            var cboEdo = $(this)
                       
            var hddDescMun = $(this).next("input[type='hidden']");
            
            //hddDescMun.val("CACA,1,CACA,2,CACA,3,CACA,4,CACA,5,CACA,6");
                                  
            var cboMun = $(this).siblings("select");

            var hddIdMun = cboMun.next("input[type='hidden']");
            
            if (hddIdMun.val() != "" && cboMun.val() == null) {                
                var idEdo = cboEdo.val();
                $.ajax({
                    type: "POST",
                    url: "Catalogos.aspx/ChecaMunicipio",
                    data: "{'idEdo':'" + idEdo + "'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    success: function (Result) {
                        var municipios;
                        hddDescMun.val("");
                        $.each(Result.d, function (key, value) {
                            if (hddDescMun.val() == "")
                                hddDescMun.val(value.MuniNombre + "," + value.IdMuni);
                            else
                                hddDescMun.val(hddDescMun.val() + "," + value.MuniNombre + "," + value.IdMuni);
                        });

                        llenaMunicipio(hddDescMun, cboMun, hddIdMun, "si");

                        hddIdMun.val(hddIdMun.val());

                    },
                    error: function (xhr, status, error) {
                        alert(xhr + "  " + status + "   " + error);
                    }
                });
            } else {
                llenaMunicipio(hddDescMun, cboMun, hddIdMun, cboEdo.val());
            }
                        
            $(cboEdo).live("change", function (e) {                
                var idEdo = cboEdo.val();
                if (idEdo != "Seleccionar...") {
                    $.ajax({
                        type: "POST",
                        url: "Catalogos.aspx/ChecaMunicipio",
                        data: "{'idEdo':'" + idEdo + "'}",
                        contentType: 'application/json; charset=utf-8',
                        dataType: "json",
                        success: function (Result) {
                            var municipios;
                            hddDescMun.val("");
                            $.each(Result.d, function (key, value) {
                                if (hddDescMun.val() == "")
                                    hddDescMun.val(value.MuniNombre + "," + value.IdMuni);
                                else
                                    hddDescMun.val(hddDescMun.val() + "," + value.MuniNombre + "," + value.IdMuni);
                            });

                            llenaMunicipio(hddDescMun, cboMun, hddIdMun, "no");

                            hddIdMun.val(cboMun.find("option:first").val());

                        },
                        error: function (xhr, status, error) {
                            alert(xhr + "  " + status + "   " + error);
                        }
                    });
                }
                else {
                    removeOptions(cboMun);
                    alert("Seleccione un estado");
                }
                });
            
            $(cboMun).change(function (e) {
                var hddIdMun = $(this).next("input[type='hidden']");
                hddIdMun.val($(this).find("option:selected").val());
            });
        });
    }
})(jQuery);