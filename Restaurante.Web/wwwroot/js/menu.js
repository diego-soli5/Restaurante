function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Menu")

    } else {
        toastr["error"](json.message, "Eliminar Menu")
    }
}


function crearEventosDeTabla() {
    document.querySelectorAll('#btnEliminar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Menu?",
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
        $("#TcDscMenuEdit").val(x.getAttribute("data-TcDscMenu"));
        $("#TdPrecioEdit").val(x.getAttribute("data-TdPrecio"));
        $("#TnIdTipoMenuEdit").val(x.getAttribute("data-TnIdTipoMenu"));
        $("#modalEditar").modal();
    }));
}

document.querySelector('#frmCrear').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Menu/Crear";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Agregar Menu");

                refrescarTabla();

                $("#modalCrear").modal("hide");
                $("#TcDscMenu").val("");
                $("#TdPrecio").val("");

            } else {
                toastr["error"](json.message, "Agregar Menu")
            }
        });
});

document.querySelector('#frmEditar').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/Menu/Actualizar/";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Editar Menu");

                refrescarTabla();

                $("#modalEditar").modal("hide");
            } else {
                toastr["error"](json.message, "Editar Menu")
            }
        });
});


function refrescarTabla() {
    $("#tblDatos").load('/Menu/ObtenerTabla', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();