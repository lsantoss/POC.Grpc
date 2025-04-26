////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////// Toastr Start ///////////////////////////////////////
// Toastr Options
toastr.options = {
    "closeButton": true,
    "progressBar": true,
    "debug": false,
    "newestOnTop": false,
    "preventDuplicates": false,
    "positionClass": "toast-top-right",
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "10000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

// Toastr global using TempData
(function () {
    if (document.getElementById('toastr-success').value) {
        toastr.success(document.getElementById('toastr-success').value);
    }
    if (document.getElementById('toastr-info').value) {
        toastr.info(document.getElementById('toastr-info').value);
    }
    if (document.getElementById('toastr-warning').value) {
        toastr.warning(document.getElementById('toastr-warning').value);
    }
    if (document.getElementById('toastr-error').value) {
        toastr.error(document.getElementById('toastr-error').value);
    }
})();
/////////////////////////////////////// Toastr End ///////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////

//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////// Common Functions Start ///////////////////////////////////////
$(function () {
    if ($.validator && $.validator.addMethod) {
        $.validator.addMethod("birthDateValidation", function (value, element) {
            if (!value) return false;

            let selectedDate = new Date(value);
            let today = new Date();
            today.setHours(0, 0, 0, 0);

            return selectedDate <= today;
        }, "Birth date cannot be greater than today's date.");

        if ($.validator.unobtrusive && $.validator.unobtrusive.adapters) {
            $.validator.unobtrusive.adapters.addBool("birthDateValidation");
        }
    }
});
/////////////////////////////////////// Common Functions End ///////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////