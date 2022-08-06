
app.controller('PeopleController', PeopleController);
PeopleController.$inject = ['PeopleService', '$scope'];

function PeopleController(PeopleService,$scope) {
    var pc = this;
    pc.Person = {ID:0,
        Name:'',
        PhoneNumber:'',
        City:'',
        Country:'',
        Gender:''
    };
    pc.IsAdd = true;
    pc.Genders = ['Male', 'Female'];
    $scope.People = [];
    pc.ID = 0;
    pc.ListItems = [];
    PeopleService.getPeople().then(function (response) { pc.People = response.data; })
    
    pc.dropboxitemselected = function (item)
    {
        pc.Person.Gender = item;
    };
    pc.Reset = function ()
    {
        pc.IsAdd = true;
        pc.Person = {
            ID: 0,
            Name: '',
            PhoneNumber: '',
            City: '',
            Country: '',
            Gender: ''
        };
    }

    //pc.toggleListItemInput = function (id)
    //{
    //    var val = angular.element(document.querySelector('#' + id)).attr('disabled');
    //    angular.element(document.querySelector(id)).removeProp("disabled");
    //    console.log("click");
    //}
    pc.addPerson = function ()
    {
        var person = {
            Name: pc.Person.Name,
            PhoneNumber: pc.Person.PhoneNumber.toString(2),
            City: pc.Person.City,
            Country: pc.Person.Country,
            Gender: pc.Person.Gender
        };
        PeopleService.addPerson(person).then(function ()
        {
            angular.element(document.querySelector('#alertBT')).click();
            angular.element(document.querySelector('#FormClose')).click();
            PeopleService.getPeople().then(function (response)
            {
                pc.People = response.data;
            })
        })
    }
    pc.setUpdatePerson = function (person)
    {
        pc.IsAdd = false;
        pc.Person.ID = person.id;
        pc.Person.Name = person.name;
        pc.Person.Gender = person.gender;
        pc.Person.PhoneNumber = person.phoneNumber;
        pc.Person.City = person.city;
        pc.Person.Country = person.country;
        
        console.log(pc.Person);
    }
    pc.updatePersonInGrid = function (person) {
        if (pc.Person.ID != person.id ||
            pc.Person.Name != person.name ||
            pc.Person.Gender != person.gender ||
            pc.Person.PhoneNumber != person.phoneNumber ||
            pc.Person.City != person.city ||
            pc.Person.Country != person.country)
        {
            PeopleService.updatePerson(person).then(function () {

                angular.element(document.querySelector('#alertBT')).click();

                PeopleService.getPeople().then(function (response) {
                    pc.People = response.data;
                })
            })
        }
        
    }
    pc.updatePerson = function ()
    {
        PeopleService.updatePerson(pc.Person).then(function () {
            angular.element(document.querySelector('#alertBT')).click();
            angular.element(document.querySelector('#FormClose')).click();
            PeopleService.getPeople().then(function (response) {
                pc.People = response.data;
            })
        })
    }
    pc.setDeleteID = function (id) {
        pc.ID = id;
    }
    pc.deletePerson = function (/*_person*/) {
        console.log(pc.ID);
        PeopleService.deletePerson(pc.ID).then(function () {
            angular.element(document.querySelector('#CloseDeleteAlert')).click();
            PeopleService.getPeople().then(function (response) {
                pc.People = response.data;
            })
        })
    }
}



