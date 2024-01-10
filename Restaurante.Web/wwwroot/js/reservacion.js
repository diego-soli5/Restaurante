function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Reservacion")

    } else {
        toastr["error"](json.message, "Eliminar Reservacion")
    }
}


function crearEventosDeTabla() {
    document.querySelectorAll('#btnEliminar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Reservacion?",
            showDenyButton: true,
            confirmButtonText: "Si",
            denyButtonText: `No`
        }).then((result) => {
            if (result.isConfirmed) {

                const url = x.href;

                x.disabled = true;

                fetch(url, { method: 'POST' })
                    .then(response => response.json())
                    .then(json => this.manageResponse(json));

            }
        });
    }));

    document.querySelectorAll('#btnEditar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        $("#Id").val(x.getAttribute("data-id"));
        $("#Id2").val(x.getAttribute("data-id"));
        $("#TnIdClienteEdit").val(x.getAttribute("data-TnIdCliente"));
        $("#TnIdMesaEdit").val(x.getAttribute("data-TnIdMesa"));
        $("#TnIdMenuEdit").val(x.getAttribute("data-TnIdMenu"));
        $("#TnCantidadEdit").val(x.getAttribute("data-TnCantidad"));

        let dataFecha = x.getAttribute("data-TfFecReserva");

        let dataDia = dataFecha.split('/')[0];
        let dataMes = dataFecha.split('/')[1];
        let dataAnio = dataFecha.split('/')[2];

        if (dataDia.length < 2) {
            dataDia = "0" + dataDia;
        }

        if (dataMes.length < 2) {
            dataMes = "0" + dataMes;
        }

        let fecha = dataAnio + '-' + dataMes + '-' + dataDia;

        document.getElementById("TfFecReservaEdit").value = fecha;

        $("#modalEditar").modal();
    }));
}

document.querySelector('#frmCrear').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Reservacion/Crear";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Agregar Reservacion");

                refrescarTabla();

                $("#modalCrear").modal("hide");
                $("#TnIdCliente").val("");
                $("#TnIdMesa").val("");
                $("#TnIdMenu").val("");
                $("#TnCantidad").val("");
                $('#TfFecReserva').val('')
                    .attr('type', 'text')
                    .attr('type', 'date');

            } else {
                toastr["error"](json.message, "Agregar Reservacion")
            }
        });
});

document.querySelector('#frmEditar').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Reservacion/Actualizar/";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Editar Reservacion");

                refrescarTabla();

                $("#modalEditar").modal("hide");
            } else {
                toastr["error"](json.message, "Editar Reservacion")
            }
        });
});


function refrescarTabla() {
    $("#tblDatos").load('/Reservacion/ObtenerTabla', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();