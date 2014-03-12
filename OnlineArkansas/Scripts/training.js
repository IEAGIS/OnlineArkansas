$(function () {
    $("#accordion").accordion({
        collapsible: true,
        heightStyle: "content",
        active: false
    });

    var courseStartDate;
    var courseEndDate;
    var courseFee;

    $(".fundamentals").click(function () {
        var courseName = $(this).attr("course");
        var courseDate = $(this).attr("date");
        var coursePrice = $(this).attr("price");
        courseStartDate = $(this).attr("startDate");
        courseEndDate = $(this).attr("endDate");
        courseFee = $(this).attr("price");

        reset();

        $("#fundamentalsRegistration").dialog("open");
        $("#courseName").text(courseName);
        $("#courseDate").text(courseDate);
        $("#coursePrice").text(coursePrice);

    });

    $('#telephone').mask('(000) 000-0000');
    $('#fax').mask('(000) 000-0000');

    $("#registrationForm").validate({
        rules: {
            firstname: {
                required: true,
                minlength: 2
            },
            lastname: {
                required: true,
                minlength: 2
            },
            address: "required",
            city: "required",
            state: "required",
            zipcode: {
                required: true,
                digits: true,
                minlength: 5
            },
            telephone: {
                required: true,
                minlength: 14,
                maxlength: 14
            },
            fax: {
                minlength: 14,
                maxlength: 14
            },
            email: {
                required: true,
                email: true
            }
        },
        messages: {
            firstname: {
                required: "Please enter your First Name",
                minlength: "Name must contain at least 2 characters"
            },
            lastname: {
                required: "Please enter your Last Name",
                minlength: "Name must contain at least 2 characters"
            },
            address: "Please provide your address",
            city: "Please provide your City",
            state: "Please select your State",
            zipcode: {
                required: "Please provide your Zip Code",
                digits: "Zip code can contain only digits",
                minlength: "Zip Code should contain atleast 5 digits"
            },
            telephone: {
                required: "Please provide your telephone number",
                minlength: "Please provide valid phone number",
                maxlength: "Please provide valid phone number"
            },
            fax: {
                minlength: "Please provide valid fax number",
                maxlength: "Please provide valid fax number"
            },
            email: {
                required: "Either an email or fax is required",
                email: "Please enter a valid email address"
            }
        },
        submitHandler: function (form) {

            $.ajax({
                url: '../Home/RegistrationForm',
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    courseName: $('#courseName').text(),
                    firstName: $('#firstname').val(),
                    lastName: $('#lastname').val(),
                    organization: $('#organization').val(),
                    address1: $('#address').val(),
                    address2: $('#address2').val(),
                    city: $('#city').val(),
                    state: $('#state').val(),
                    zipCode: $('#zipcode').val(),
                    phone: $('#telephone').val(),
                    fax: $('#fax').val(),
                    emailAddress: $('#email').val(),
                    courseStartDate: courseStartDate,
                    courseEndDate: courseEndDate,
                    courseFee: courseFee
                }),
                success: function (result) {
                    $("#fundamentalsRegistration").dialog("close");
                    alert("Congratulations! " + result.firstName + ". You have successfully registered. Invoice and location instructions will be mailed or faxed to you prior to the class.");
                },
                error: function (result) {
                    alert("Oops! Your registration has failed. Please try again.");
                }

            });
            return false;
        }


    });

    function reset() {
        $('#firstname').val('');
        $('#lastname').val('');
        $('#organization').val('');
        $('#address').val('');
        $('#address2').val('');
        $('#city').val('');
        $('#state').val('AR');
        $('#zipcode').val('');
        $('#telephone').val('');
        $('#fax').val('');
        $('#email').val('');
        $("#registrationForm").validate().resetForm();
    }


    $("#fundamentalsRegistration").dialog({
        autoOpen: false,
        height: 650,
        width: 700,
        modal: true,
        buttons: {
            "Register": function () {
                $("#registrationForm").submit();

            },
            Cancel: function () {
                reset();
                $(this).dialog("close");
            }
        }
    });
});
