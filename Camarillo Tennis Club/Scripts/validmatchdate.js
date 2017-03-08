$(function () {

    jQuery.validator.addMethod('validmatchdate', function (value, element, params) {
        var currentDate = new Date();
        if (Date.parse(value) > currentDate) {
            return false;
        }
        return true;
    }, '');

    jQuery.validator.unobtrusive.adapters.add('validmatchdate', function (options) {
        options.rules['validmatchdate'] = {};
        options.messages['validmatchdate'] = options.message;
    });

}(jQuery));