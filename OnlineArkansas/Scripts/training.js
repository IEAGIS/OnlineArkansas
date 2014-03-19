$(function () {
    $("#accordion").accordion({
        collapsible: true,
        heightStyle: "content",
        active: false
    });

    var courseNamesList = [];
    var courseStartDatesList = [];
    var courseEndDatesList = [];
    var courseFeeList = [];

    $(".fundamentals").click(function () {
        reset();
        $("#fundamentalsRegistration").dialog("open");
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


            if ($('input[name="courses[]"]:checked').length > 0) {

                $(".ajax-loader").html("<img src='../img/loader.gif'>");

                for (i = 1; i <= $('input[name="courses[]"]:checked').length; i++) {
                    if ($('#course' + i).is(':checked') == true) {
                        courseNamesList.push($('#courseName' + i).text());
                        courseStartDatesList.push($('#course' +i ).attr("courseStartDate" + i));
                        courseEndDatesList.push($('#course' +i).attr("courseEndDate" +i ));
                        courseFeeList.push($('#coursePrice' +i).text());
                    }
                }

                $.ajax({
                    url: '../Home/RegistrationForm',
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({

                        courseNames: courseNamesList,
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
                        courseStartDates: courseStartDatesList,
                        courseEndDates: courseEndDatesList,
                        courseFee: courseFeeList
                    }),
                    success: function (result) {
                        $(".ajax-loader").html('');
                        $("#fundamentalsRegistration").dialog("close");
                        alert("Congratulations! " + result.firstName + ". You have successfully registered. Invoice and location instructions will be mailed or faxed to you prior to the class.");
                    },
                    error: function (result) {
                        $(".ajax-loader").html('');
                        alert("Oops! Your registration has failed. Please try again.");
                    }

                });
            }
            else {

                $('#coursesChecked').text('Please select at least one course');
            }

            return false;
        }


    });

    function checkedCoursesLength() {
        var len = $('input[name="courses[]"]:checked').length;
        if (len <= 0) {
            $('#coursesChecked').text('Please select at least one course');
        }
        else {
            $('#coursesChecked').text('');
        }
    }

    $('input[name="courses[]"]').on('click', checkedCoursesLength);

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
        $('input[name="courses[]"]').attr('checked', false);
        $('#coursesChecked').text('');
        $(".ajax-loader").html('');
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
