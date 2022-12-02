window.onload = function() {

    var form_sub = document.forms.sub_form;

    form_sub.onsubmit = checking_form;

    function checking_form() {
        var form_sub = document.forms.sub_form;
        var name_fname = form_sub.TeacherFname.value;
        var name_f = form_sub.TeacherFname;
        var name_lname = form_sub.TeacherLname.value;
        var name_l = form_sub.TeacherLname;
        var emp_num = form_sub.EmployeeNumber.value;
        var num_emp = form_sub.EmployeeNumber;
        var h_date = form_sub.HireDate.value;
        var date_h = form_sub.HireDate;
        var salary = form_sub.Salary.value;
        var sal_ary = form_sub.Salary;

        if (name_fname === "") {
            name_f.style.background = "red";
            name_f.focus();
            return false;
        }

        if (name_lname === "") {
            name_l.style.background = "red";
            name_l.focus();
            return false;
        }

        if (emp_num === "") {
            num_emp.style.background = "red";
            num_emp.focus();
            return false;
        }

        if (h_date === "") {
            date_h.style.background = "red";
            date_h.focus();
            return false;
        }

        if (salary === "") {
            sal_ary.style.background = "red";
            sal_ary.focus();
            return false;
        }
        return false;
    }
    
}
