function showModal(modalId, modalBodyId, id) {
    var url = $(modalId).data('url');

    $.ajax({
        url: url,
        type: "GET",
        //contentType: "text/html; charset=utf-8",
        data: { "id": id }
    })
        .done(function (data) {
            $(modalBodyId).html(data);
            $(modalId).modal('toggle'); });

}