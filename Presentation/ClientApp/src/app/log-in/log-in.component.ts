import { Component, OnInit } from '@angular/core';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import { LogInService } from '../Services/log-in-service.service';
import { IUser } from '../Models/IUser';
import { GlobalsService } from '../Shared/globals.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'logIn',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  user:IUser = null;
  errorMessage = '';
  angForm: FormGroup;

  constructor(private fb: FormBuilder,private logInService: LogInService,private global:GlobalsService,
    private route: ActivatedRoute,private router: Router) {
    this.createForm();
   }

   get userName(): any { return this.angForm.get('userName'); }

   getUserByName(): void{
    this.logInService.getUser(this.userName.value).subscribe({
      next: userInfo => {
        this.user = userInfo
        if(this.user != null)
        {
        this.errorMessage = '';
         this.global.setLoggedInUser(this.user);
         this.global.orderedItemList = [];
         this.router.navigate(['/products'])
        }
        else
        {
          this.errorMessage = 'This user not found';
        }
      },
      error: err => this.errorMessage = err,
    });
   }
   createForm() {
    this.angForm = this.fb.group({
      userName: ['', [Validators.required,
      Validators.pattern(/^[\w\s]+$/)] ]
    });
  }
  ngOnInit() {
    this.user  = this.global.getLoggedInUSer();
    if (this.user != null)
    {
      this.router.navigate(['/products'])
    }
  }

}
