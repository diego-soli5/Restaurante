function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Tipo de Menu")

    } else {
        toastr["error"](json.message, "Eliminar Tipo de Menu")
    }
}


function crearEventosDeTabla() {
    document.querySelectorAll('#btnEliminar').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Tipo de Menu?",
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
        $("#TcDscTipoMenuEdit").val(x.getAttribute("data-TcDscTipoMenu"));
        $("#modalEditar").modal();
    }));
}

document.querySelector('#frmCrear').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/TipoMenu/Crear";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Agregar Tipo de Menu");

                refrescarTabla();

                $("#modalCrear").modal("hide");
                $("#TcDscTipoMenu").val("");
            } else {
                toastr["error"](json.message, "Agregar Tipo de Menu")
            }
        });
});

document.querySelector('#frmEditar').addEventListener('submit', (e) => {
    e.preventDefault();

    const url = "/TipoMenu/Actualizar/";

    const body = new FormData(e.target);

    fetch(url, { body: body, method: 'POST' })
        .then(response => response.json())
        .then(json => {
            if (json.success) {
                toastr["success"](json.message, "Editar Tipo de Menu");

                refrescarTabla();

                $("#modalEditar").modal("hide");
                $("#modalEditar").modal("hide");
            } else {
                toastr["error"](json.message, "Editar Tipo de Menu")
            }
        });
});


function refrescarTabla() {
    $("#tblDatos").load('/TipoMenu/ObtenerTabla', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();