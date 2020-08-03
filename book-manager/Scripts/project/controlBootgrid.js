function configureControls() {

    const grid = $('#booksGrid').bootgrid({
        ajax: true,
        url: listUrl,
        searchSettings: {
            characters: 4
        },
        formatters: {
            'Actions': function (column, row) {
                const buttons = "<a class='btn btn-warning btn-sm' data-row-id='" + row.Id + "' data-action='Details' href='#'> <span class='glyphicon glyphicon-list'></span> </a> " +
                    "<a class='btn btn-info btn-sm' data-row-id='" + row.Id + "' data-action='Edit' href='#'> <span class='glyphicon glyphicon-edit'></span> </a> " +
                    "<a class='btn btn-danger btn-sm' data-row-id='" + row.Id + "' data-action='Delete' href='#'> <span class='glyphicon glyphicon-trash'></span> </a>";

                return buttons;
            }
        }
    });

    grid.on('loaded.rs.jquery.bootgrid', function () {
        grid.find('a.btn').each(function (index, element) {
            const actionButton = $(element);
            const action = actionButton.data('action');
            const id = actionButton.data('row-id');

            actionButton.on('click', () => openModal(action, id));
        });
    });

    $('a.btn').click(function () {
        const action = $(this).data('action');
        openModal(action);
    });
}


function openModal(action, param) {
    //let url = '{controller}/{action}/{param}';
    let url = '{action}/{param}';

    const controller = 'books';

    //url = url.replace('{controller}', controller);
    url = url.replace('{action}', action);

    const parameters = param ? param : '';

    url = url.replace('{param}', parameters);

    $('#modalContent').load(url, () => $('#myModal').modal('show'));
}