app.service('PeopleService', PeopleService);
PeopleService.$inject = ['$http'];

function PeopleService($http) {
	var pc = this;
	pc.getPeople = function () {
		return $http({
			method: 'GET',
			url: '/People'
		});
	}
	pc.deletePerson = function (id) 
	{
		return $http({
			method: 'DELETE',
			url: '/People/'+id
		});
	}
	pc.addPerson = function(_person)
	{
		return $http({
			method: 'POST',
			url: '/People',
			data: _person
		});
	}
	pc.updatePerson = function (_person) {
		return $http({
			method: 'PUT',
			url: '/People',
			data: _person
		});
	}
	
}