//INICIA FUNCIONES SweetAlert
function swalAlert(title, message, success) {
    if (success) {
        Swal.fire(
            title,
            message,
            'success'
        )
    }
    else {
        Swal.fire(
            title,
            message,
            'error'
        )
    }
}

function openRedirectionModal(title, url) {
    let timerInterval
    Swal.fire({
        title: title,
        html: 'Redireccionando en <b></b> milisegundos.',
        timer: 5000,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading()
            timerInterval = setInterval(() => {
                const content = Swal.getHtmlContainer()
                if (content) {
                    const b = content.querySelector('b')
                    if (b) {
                        b.textContent = Swal.getTimerLeft()
                    }
                }
            }, 100)
        },
        willClose: () => {
            clearInterval(timerInterval)
        }
    }).then((result) => {
        window.location.href = url
    });
}
//FIN FUNCIONES SweetAlert


toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

/*
document.querySelectorAll('input[pattern]').forEach(x => x.addEventListener('input', function (e) {
    x.value = x.value.replace(/[^0-9]/g, "");
}));*/

function maxLengthCheck(object) {
    if (object.value.length > object.maxLength)
        return false;
}