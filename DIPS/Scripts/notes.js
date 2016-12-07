var notes = {};

notes.loadNoteById = function (id) {
    console.log("looking up notes");
    var uri = '/api/Notes';

    var location = window.location;
    console.log(location);

    $.getJSON(uri + '/' + id)
        .done(function (data) {
            var notesPlaceHolder = $("#notePlaceHolder");
            $.each(data, function (key, note) {
                var noteHtml = '<h1>';
                noteHtml += '<a href="api/Notes/' + note.Id + '">' + note.Name + '</a>';
                noteHtml += '</h1>';

                noteHtml += '<hr>';
                noteHtml += '<p class="lead">' + note.Text + '</p>';
                notePlaceHolder.append(noteHtml);
            });
        })
        .fail(function (error) {
            alert("error " + error)
        });
}