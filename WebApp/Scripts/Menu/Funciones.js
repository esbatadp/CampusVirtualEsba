function GuardarFormulario()
{
    $.ajax({
        url: '/Menu/Guardar',
        data: $('#MenuForm').serialize(),
        type: 'POST',
        dataType: 'json',
        success: function (data)
        {
            if (data.EsCorrecta)
            {
                debugger;
                alert("EsCorrecto");
            }
            else
            {
                debugger;
                alert(data.Mensaje);
            }
        }
    });


}