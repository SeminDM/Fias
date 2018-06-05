$('#modalForm').submit(function () {
    var url = $(this).attr('action');
    $.post(url, $(this).serialize(), function (data) {
        if (data !== "") {
            $('#theModalBody').html(data);
        } else {
            $('#theModal').modal('toggle');
            location.reload();
        }
    })
    return false;
});