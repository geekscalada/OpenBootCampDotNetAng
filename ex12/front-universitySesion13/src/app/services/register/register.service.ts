import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private _http: HttpClient) { }

  registerUser(
    id : string,
    createdBy: string,
    createdAt: string,
    updatedBy: string,
    updatedAt: string,
    deletedBy: string,
    deletedAt: string,
    isDeleted: string,
    name: string,
    lastName: string,
    email: string,
    password: string
  ){

    let body = {id, createdBy, createdAt, updatedBy,updatedAt,
    deletedBy, deletedAt, isDeleted, name, lastName, email,
    password
    }

    return this._http.post('https://localhost:7190/api/Users', body )


  }


}
