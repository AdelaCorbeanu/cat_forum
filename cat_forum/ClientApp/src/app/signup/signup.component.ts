import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignUpComponent implements OnInit {
  name!: string;
  email!: string;
  password!: string;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    console.log(this.name, this.email, this.password);
    // Add code to send sign up data to the server
  }
}
