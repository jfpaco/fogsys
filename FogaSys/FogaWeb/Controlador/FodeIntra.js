/*Metodo y funciones de la pagina*/
function deleteFile(file, idBoton) {
    $('#' + idBoton).parent().find('.uploadStatus').text("Eliminando...");
    $.ajax({
        url: "UploadHandler.ashx?file=" + file,
        type: "GET",
        cache: false,
        async: true,
        success: function (html) {
            $('#' + idBoton).siblings('span:first').html("");
            $('#' + idBoton).parent().find('.uploadStatus').html("El archivo a sido eliminado");
            $('#' + idBoton).siblings("input[type='hidden']").val("");
            $('#' + idBoton).show();
        }
    });
}

/*Cuando termina la carga de la página ONLOAD*/
$(document).ready(function(){

    $(".uploadStatus").siblings("input[type='hidden']").each(function () {
        var hddValor = $(this).val();        
        if (hddValor != '') {            
            var idBoton = $(this).siblings("input[type='submit']").attr('id');
            $("#" + idBoton).hide();
            $(this).siblings('.uploadStatus').text('Agregado correctamente: ');            
            $(this).siblings('.uploadedFile').append(hddValor + "<input type='button' onclick=\"DeleteFile('" + hddValor + "', '" + idBoton + "')\" Value='Eliminar' class='delete'/><a href='Archivos/" + hddValor + "' target='_blank'>Ver</a>");            
        }
    });
            
    $("input[type='submit'].uploadButton").each(function () {
        var boton = this;
        var idBoton = boton.id;
        new AjaxUpload('#' + idBoton, {
            action: 'UploadHandler.ashx',
            onComplete: function (file, response) {
                $('#' + idBoton).parent().find('.uploadStatus').text('Agregado correctamente: ');
                $('#' + idBoton).siblings('span:first').append(response + "<input type='button' onclick=\"deleteFile('" + response + "', '" + idBoton + "')\" Value='Eliminar' class='delete'/><a href='Archivos/" + response + "' target='_blank'>Ver</a>");
                $('#' + idBoton).siblings("input[type='hidden']").val(response);
                //$('#' + boton.id).siblings('span:first').append("<img src='resources/btndelete.png' onclick=\"DeleteFile('" + response + "', '" + boton.id + "')\"  class='delete'/>" + response + "");                        
                $("#" + idBoton).hide();
            },
            onSubmit: function (file, ext) {
                if (!(ext && /^(pdf|jpg|png)$/i.test(ext))) {
                    alert('Formato no valido ' + ext);
                    return false;
                }
                $('#' + boton.id).parent().find('.uploadStatus').text("Subiendo...");
            }
        });
    });

});