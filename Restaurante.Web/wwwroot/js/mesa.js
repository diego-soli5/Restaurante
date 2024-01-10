function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Mesa")

    } else {
        toastr["error"](json.message, "Eliminar Mesa")
    }
}


function crearEventosDeTabla() {
    document.querySelectorAll('#btnEliminar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Mesa?",
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
        $("#TcDscMesaEdit").val(x.getAttribute("data-TcDscMesa"));
        $("#modalEditar").modal();
    }));
}

document.querySelector('#frmCrear').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Mesa/Crear";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Agregar Mesa");

                refrescarTabla();

                $("#modalCrear").modal("hide");
                $("#TcDscMesa").val("");
            } else {
                toastr["error"](json.message, "Agregar Mesa")
            }
        });
});

document.querySelector('#frmEditar').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Mesa/Actualizar/";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Editar Mesa");

                refrescarTabla();

                $("#modalEditar").modal("hide");
            } else {
                toastr["error"](json.message, "Editar Mesa")
            }
        });
});


function refrescarTabla() {
    $("#tblDatos").load('/Mesa/ObtenerTabla', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();