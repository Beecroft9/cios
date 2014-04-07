$(document).ready(function () {


    var ajaxFormSubmit = function () {
        var form = $(this);

        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data: form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $(form.attr("data-ciosApp-target"));
            var $data = $(data);
            target.replaceWith($data);
            $data.effect("bounce", "fast");
        });

        return false;
    };

    $("form[data-ciosApp-ajax='true']").submit(ajaxFormSubmit);


    var submitAutocompleteForm = function (event, ui) {
        var input = $(this);
        input.val(ui.item.label);

        var form = input.parents("form:first");
        form.submit();
    }

    var createAutocomplete = function () {
        var input = $(this);

        var options = {
            source: input.attr("data-ciosApp-autocomplete"),
            select: submitAutocompleteForm
        }

        input.autocomplete(options);
    };

    $("input[data-ciosApp-autocomplete]").each(createAutocomplete);



});