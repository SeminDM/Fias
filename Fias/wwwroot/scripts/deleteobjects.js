function deleteobjects() {
    var checks = $("input[id='check']");
    var ids = [];
    for (i = 0; i < checks.length; i++)
        if (checks[i].checked) {
            var id = $(checks[i].parentNode.parentNode).data('objectid');
            ids.push(id);
        }

    if (ids.length === 0) {
        alert("Выберете объекты!");
        return;
    }

    var body = JSON.stringify({
        "ids": ids
    });

    $.ajax({
        type: 'POST',
        url: '/AddressObject/Delete',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: { "ids" : ids }
    })
        .done(function (data) {
            location.reload();
        })
}
