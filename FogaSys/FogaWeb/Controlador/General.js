/// <reference path="../Scripts/jquery-1.7.1.min.js" />
/// <reference path="../Scripts/jquery-ui-1.10.4.custom.min.js" />
function msj(texto) {
    alert(texto);
}

function mensaje(texto, url) {
    alert(texto);
    setTimeout(function () { redirecciona(url) }, 500);
}

function redirecciona(urlOrigen) {
    location.href = urlOrigen;
}

function validaHdd(oScr, args) {    
    var idValor = $("#" + $(oScr).attr("title")).val();
    if (idValor != "") {
        args.IsValid = true;
    } else {
        args.IsValid = false;
    }
}

$(document).ready(function () {
    //Mascara para fechas
    $(".fecha").keyup(function () {
        var pat = new Array(2, 2, 4)
        var elem = this;
        var separador = '/';
        var numerico = true;
        if (elem.valoranterior != elem.value) {
            valor = elem.value;
            largo = valor.length;
            valor = valor.split(separador);
            valor2 = "";

            for (i = 0; i < valor.length; i++) {
                valor2 += valor[i];
            }

            if (numerico) {
                for (j = 0; j < valor2.length; j++) {
                    if (isNaN(valor2.charAt(j))) {
                        letra = new RegExp(valor2.charAt(j), "g");
                        valor2 = valor2.replace(letra, "");
                    }
                }
            }

            valor = "";
            valor3 = new Array();
            for (n = 0; n < pat.length; n++) {
                valor3[n] = valor2.substring(0, pat[n]);
                valor2 = valor2.substr(pat[n]);
            }

            for (q = 0; q < valor3.length; q++) {
                if (q == 0) {
                    valor = valor3[q];
                } else {
                    if (valor3[q] != "") {
                        if (valor3[1] > 12) {
                            valor = valor3[2];
                        } else if (valor3[0] > 31) {
                            valor = valor3[1] + separador + valor3[2];
                        } else {
                            valor += separador + valor3[q];
                        }

                    }
                }
            }

            elem.value = valor;
            elem.valoranterior = valor;
        }

    });

    $(".moneda").change(function () {
        var elem = this;
        var num = elem.value.replace("/\./g,");
        if (!isNaN(num)) {            
            num = num.toString().split("").reverse().join("").replace(/(?=\d*\.?)(\d{3})/g,"$1,");
            num = num.split("").reverse().join("").replace(/^[\,]/,"");
            elem.value = num;                        
        }
    });

});