var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { TemplateRef, ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { User } from './user';
import { UserService } from './user.service';
var AppComponent = /** @class */ (function () {
    function AppComponent(serv) {
        this.serv = serv;
        this.users = new Array();
    }
    AppComponent.prototype.ngOnInit = function () {
        this.loadUsers();
    };
    //загрузка пользователей
    AppComponent.prototype.loadUsers = function () {
        var _this = this;
        this.serv.getUsers().subscribe(function (data) {
            _this.users = data;
        });
    };
    // добавление пользователя
    AppComponent.prototype.addUser = function () {
        this.editedUser = new User(0, "", 0);
        this.users.push(this.editedUser);
        this.isNewRecord = true;
    };
    // редактирование пользователя
    AppComponent.prototype.editUser = function (user) {
        this.editedUser = new User(user.Id, user.Name, user.Age);
    };
    // загружаем один из двух шаблонов
    AppComponent.prototype.loadTemplate = function (user) {
        if (this.editedUser && this.editedUser.Id == user.Id) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    };
    // сохраняем пользователя
    AppComponent.prototype.saveUser = function () {
        var _this = this;
        if (this.isNewRecord) {
            // добавляем пользователя
            this.serv.createUser(this.editedUser).subscribe(function (data) {
                _this.statusMessage = 'Данные успешно добавлены',
                    _this.loadUsers();
            });
            this.isNewRecord = false;
            this.editedUser = null;
        }
        else {
            // изменяем пользователя
            this.serv.updateUser(this.editedUser.Id, this.editedUser).subscribe(function (data) {
                _this.statusMessage = 'Данные успешно обновлены',
                    _this.loadUsers();
            });
            this.editedUser = null;
        }
    };
    // отмена редактирования
    AppComponent.prototype.cancel = function () {
        // если отмена при добавлении, удаляем последнюю запись
        if (this.isNewRecord) {
            this.users.pop();
            this.isNewRecord = false;
        }
        this.editedUser = null;
    };
    // удаление пользователя
    AppComponent.prototype.deleteUser = function (user) {
        var _this = this;
        this.serv.deleteUser(user.Id).subscribe(function (data) {
            _this.statusMessage = 'Данные успешно удалены',
                _this.loadUsers();
        });
    };
    __decorate([
        ViewChild('readOnlyTemplate'),
        __metadata("design:type", TemplateRef)
    ], AppComponent.prototype, "readOnlyTemplate", void 0);
    __decorate([
        ViewChild('editTemplate'),
        __metadata("design:type", TemplateRef)
    ], AppComponent.prototype, "editTemplate", void 0);
    AppComponent = __decorate([
        Component({
            selector: 'my-app',
            templateUrl: './app.component.html',
            providers: [UserService]
        }),
        __metadata("design:paramtypes", [UserService])
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
//# sourceMappingURL=app.component.js.map