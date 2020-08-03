const actionButton = $('input[type="button"]');
const form = $('#createForm');

actionButton.on('click', () => submit());

function submit() {
    if (form.valid()) {
        const url = form.prop('action');
        const method = form.prop('method');
        const formData = form.serialize();

        $.ajax({
            url: url,
            type: method,
            data: formData,
            success: handleSuccess,
            error: handleError
        });

        function handleSuccess(response) {
            if (response.result) {
                toastr.success(response.message);
                $('#myModal').modal('hide');
                $('#booksGrid').bootgrid('reload');
            } else {
                toastr.error(response.message);
            }
        }

        function handleError(error) {
            toastr.error(error);
        }
    }
} 