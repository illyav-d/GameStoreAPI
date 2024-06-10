import { Component } from '@angular/core';
import { User } from '../../../models/user.model';
import { UserService } from '../../../service/user.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-admin-user-management',
  templateUrl: './admin-user-management.component.html',
  styleUrl: './admin-user-management.component.css'
})
export class AdminUserManagementComponent {
  userList: User[] = []
  userForms: { [key: number]: FormGroup } = {};

  constructor(private userService: UserService, private formBuilder: FormBuilder) {
    this.loadUsersInArray();
  }
  loadUsersInArray() {
    this.userService.getAllUsers().subscribe((response: Array<User>) => {
      this.userList = response;
      this.userList.forEach(user => { this.userForms[user.id] = this.formBuilder.group({ active: [user.active] }) })
    })
  }
  onToggleActive(userID: number): void {
    const isActive = this.userForms[userID].get('active')?.value;
    this.userService.updateUserActiveStatus(userID, isActive).subscribe(() => {
      this.loadUsersInArray();
    });
  }
}
