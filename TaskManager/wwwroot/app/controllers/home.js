var app = angular.module("TaskManager", []);

app.controller("HomeController", function ($scope, $http) {


    $scope.load = function () {
        $http.get('/api/Tarea/GetAll' )
            .then(function (result) {
                $scope.tareas = result.data;
                console.log($scope.tareas)
            })
    }

    $scope.reloadPage = function () {
        load();
    }

    $scope.AddTask = function () {
        $http.post('/api/Tarea/Post', $scope.tarea
        ).then(function (result) {
            console.log(result)
            $scope.opcion = "alert-success";
            $scope.message = "Tarea agregada correctamente!";
        },
            function (error) {
                $scope.opcion = "alert-danger";
                $scope.message = "No fue posible agregar una nueva tarea.";
            })
        $scope.reloadPage();
    }

    $scope.MarkAsDone = function (tarea) {
        let task = tarea;
        task.Estado = true;
        $http.put('/api/Tarea/Put', task
        ).then(function (result) {
          
            console.log(result)
            $scope.opcion = "alert-success";
            $scope.message = `Tarea ${task.Titulo} realizada!`;
        },
            function (error) {
                $scope.opcion = "alert-danger";
                $scope.message = "No fue posible agregar una nueva tarea.";
            })
        $scope.reloadPage();
    }

    $scope.UpdateTask = function () {
        $http.put('/api/Tarea/Put', $scope.editTask
        ).then(function (result) {
            console.log(result)
            $scope.opcion = "alert-success";
            $scope.message = "Tarea actualizada correctamente!";
        },
            function (error) {
                $scope.opcion = "alert-danger";
                $scope.message = "No fue posible actualizar la tarea.";
            })
        $scope.reloadPage();
    }

    $scope.GetTask = function (id) {
        $http.get(`/api/Tarea/Get/${id}`)
            .then(function (result) {
                $scope.editTask = result.data;
                console.log($scope.editTask)
            })
    }

    $scope.DeleteTask = function (id) {
        $http.delete(`/api/Tarea/Delete/${id}`)
            .then(function (result) {
                console.log(result)
                $scope.opcion = "alert-warning";
                $scope.message = "Tarea eliminada correctamente!";
            },
                function (error) {
                    $scope.opcion = "alert-danger";
                    $scope.message = "No fue posible eliminar la tarea.";
                })
        $scope.reloadPage();
    }
});