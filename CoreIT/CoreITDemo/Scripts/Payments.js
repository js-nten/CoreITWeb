$().ready(function () {

    var PaymentsViewModel = function () {
        var self = this;
        self.Payments = ko.observable([]);
        self.EmployeesList = ko.observableArray([]);

        self.readonlyTemplate = ko.observable("readonlyTemplate");
        self.editTemplate = ko.observable();

        //List of Employee Attributes
        self.EmpId = ko.observable('');
        self.PaidAmount = ko.observable('');
        self.PaymentType = ko.observable('');
        self.SelectedEmployee = ko.observable();
        //self.Firstname = ko.observable('');
        //self.Lastname = ko.observable('');
        //self.SelectedImmigrationStatus = ko.observable();
        //self.Salary = ko.observable();
        //self.HireDate = ko.observable();
        //self.SalaryEffectiveDate = ko.observable();
        //self.Address1 = ko.observable();
        //self.Address2 = ko.observable();
        //self.City = ko.observable();
        //self.StateOrProvince = ko.observable();
        //self.PostalCode = ko.observable();
        //self.Contact = ko.observable();
        //self.EmailId = ko.observable();
        //self.FullAddress = ko.observable();

        var Payment = {
            EmpId: self.EmpId,
            PaidAmount: self.PaidAmount,
            PaymentType: self.PaymentType
        };

        self.Payment = ko.observable();
        
        //Current template binder
        self.currentTemplate = function (templt) {
            return templt === self.editTemplate() ? 'editTemplate' : self.readonlyTemplate();
        }.bind(self);

        //Get All Employee
        self.Retrieve = function () {

            self.Payments.removeAll();

            $.getJSON("/api/PaymentsAPI", function (data) {
                $.each(data, function (key, value) {
                    if (value != 1) {
                        $.each(value, function (k, l) {
                            self.Payments.push(l); 
                        });
                    };
                });
            });            
        };

        //Retrieve Immigration Enumerations from server
        self.EmployeesList = function () {

            self.EmployeesList.removeAll();

            $.getJSON("/api/EmployeeAPI", function (data) {
                $.each(data, function (key, value) {

                    if (value != 1) {
                        $.each(value, function (k, l) {                            
                            self.EmployeesList.push(l.EmpId + "-" + l.Firstname);
                            alert(l.EmpId);
                        });
                    };
                });
            });
        };


        //Add a new employee
        self.addEmployee = function () {
            
            //Employee.EmpId = 9;
            //Employee.Firstname = self.Firstname();
            //Employee.Lastname = self.Lastname();
            //Employee.ImmigrationStatus = self.SelectedImmigrationStatus();
            //Employee.Salary = self.Salary();
            //Employee.HireDate = self.HireDate();
            //Employee.SalaryEffectiveDate = self.SalaryEffectiveDate();
            //Employee.Address1 = self.Address1();
            //Employee.Address2 = self.Address2();
            //Employee.City = self.City();
            //Employee.StateOrProvince = self.StateOrProvince();
            //Employee.PostalCode = self.PostalCode();
            //Employee.Contact = self.Contact();
            //Employee.EmailId = self.EmailId();
            //alert(self.EmailId());

            //$.ajax({
            //    type: "POST",
            //    url: "api/Employeeapi/",
            //    datatype: "json",
            //    cache:false,
            //    data: Employee,
            //    success: function (data) {
            //        alert('added employee successfully!!!');
            //        self.Retrieve();
            //    },
            //    error: function (err) {
            //        alert('Error occured while adding employee..' + err.statusCode);
            //    }
            //});
        };

        //Update Employee
        self.UpdateEmployee = function (_employee) {

            //$.ajax({
            //    type: "PUT",
            //    url: "/api/Employeeapi/" + _employee.EmpId,
            //    datatype: "json",
            //    data: _employee,
            //    success: function (_retData) {
            //        alert('updated successfully');
            //    },
            //    error: function (err) {
            //        alert('Error occured while update');
            //    }
            //});

            self.editTemplate("readonlyTemplate");
        };

        //Delete Employee
        self.DeleteEmployee = function (_payments) {
            alert('Deleting Payment:' + _payments.EmpId);
            self.Retrieve();
            self.reset();
        };

        self.reset = function (t) {
            alert('cancel triggered');
            self.editTemplate("readonlyTemplate");
            self.Retrieve();
        };


        //Default action
        self.EmployeesList();
        self.Retrieve();
    };

    ko.applyBindings(new PaymentsViewModel());

});