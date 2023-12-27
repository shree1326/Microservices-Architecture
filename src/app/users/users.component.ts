import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../Model/User';
import { UsersService } from './users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  UserList?: Observable<User[]>;
  UserList1?: Observable<User[]>;
  userForm: any;
  userId = 0;
  PageNo = 1;
  PageSize = 2;
  SortOrder='UserId_ASC';

  constructor(private formbulider: FormBuilder,
     private userService: UsersService,private router: Router,
     private toastr: ToastrService) { }

  ngOnInit() {
    this.userForm = this.formbulider.group({
      userName: ['', [Validators.required]],
      address: ['', [Validators.required]]
    });
    this.getUserList(this.PageNo, this.PageSize, this.SortOrder);
  }
  getUserList(PageNo : number, PageSize  : number, SortOrder: string) {
    this.UserList1 = this.userService.getUserList(PageNo, PageSize, SortOrder);
    this.UserList = this.UserList1;
  }
  PostUser(user: User) {
    const user_Master = this.userForm.value;
    this.userService.postUserData(user_Master).subscribe(
      () => {
        this.getUserList(this.PageNo, this.PageSize, this.SortOrder);
        this.userForm.reset();
        this.toastr.success('Data Saved Successfully');
      }
    );
  }
  UserDetailsToEdit(id: string) {
    this.userService.getUserDetailsById(id).subscribe(userResult => {
      this.userId = userResult.userId;
      this.userForm.controls['userName'].setValue(userResult.userName);
      this.userForm.controls['address'].setValue(userResult.address);
    });
  }
  UpdateUser(user: User) {
    user.userId = this.userId;
    const user_Master = this.userForm.value;
    this.userService.updateUser(user_Master).subscribe(() => {
      this.toastr.success('Data Updated Successfully');
      this.userForm.reset();
      this.getUserList(this.PageNo, this.PageSize, this.SortOrder);
    });
  }

  DeleteUser(id: number) {
    if (confirm('Do you want to delete this user?')) {
      this.userService.deleteUserById(id).subscribe(() => {
        this.toastr.success('Data Deleted Successfully');
        this.getUserList(this.PageNo, this.PageSize, this.SortOrder);
      });
    }
  }

  Clear(user: User){
    this.userForm.reset();
  }

}