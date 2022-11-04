import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from 'src/app/services/register/register.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})
export class RegisterFormComponent implements OnInit {


  registerForm: FormGroup = this._formBuilder.group({});


  constructor(
    private _formBuilder: FormBuilder,
    private _router:Router,
    private _registerService : RegisterService


  ) { 

    //Creamos el formulario vacío en el constructor
    this.registerForm = this._formBuilder.group(
      {
        id: [0 , Validators.required],
        createdBy: ["string", Validators.required],
        createdAt: ["2022-11-02T09:22:19.719Z", Validators.required],
        updatedBy: ["string", Validators.required],
        updatedAt: ["2022-11-02T09:22:19.719Z", Validators.required],
        deletedBy: ["string", Validators.required],
        deletedAt: ["2022-11-02T09:22:19.719Z", Validators.required],
        isDeleted: [false, Validators.required],
        name: ["string", Validators.required],
        lastName: ["string", Validators.required],
        email: ["user@example.com", Validators.required],
        password: ["string", Validators.required]
      })
  } //end constructor

  registerUser(){

    let {id, createdBy, createdAt, updatedBy,updatedAt,
      deletedBy, deletedAt, isDeleted, name, lastName, email,
      password
      } = this.registerForm?.value;

    this._registerService.registerUser(id, createdBy, createdAt, 
      updatedBy, updatedAt, deletedBy, deletedAt, isDeleted, name, lastName, 
      email, password).subscribe(
        {
          next: (response: any) => {
            if(response.token){
              console.log('Response', response);              
            }
          },
          error: (error: any) => {
            console.error(`[ERROR]: Something wrong happend: ${error}`);
            
          },
          complete: () => {
            console.info('Authentication process finished');
            this.registerForm.reset();
          }
        }
      ) 

  }


  ngOnInit(): void {
  }

}
