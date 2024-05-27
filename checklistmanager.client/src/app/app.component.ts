import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Response } from '../models/response.model';
import { Checklist } from '../models/checklist.model';
import { Vehicle } from '../models/vehicle.model';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public checklists: Checklist[] = [];
  public vehicles: Vehicle[] = [];
  public httpOptions = {
    headers: new HttpHeaders({
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient, private router: Router) {}

  @Output() onSubmit = new EventEmitter<Checklist>();

  ngOnInit() {
    this.getCars();
    this.getChecklists();
  }

  getChecklists() {
    this.http.get<Response<Checklist[]>>('https://localhost:7228/Checklist', this.httpOptions).subscribe(
      (result) => {
        this.checklists = result.data
      }, 
      (error) => {
        console.error(error);
      }
    );
  }

  getCars() {

    this.http.get<Response<Vehicle[]>>('https://localhost:7228/Vehicle', this.httpOptions).subscribe(
      (result) => {
        this.vehicles = result.data
      },
      (error) => {
        console.error(error);
      }
    );
  }

  postChecklist(checklist: Checklist) {
    this.http.post<Response<Checklist[]>>('https://localhost:7228/Checklist', checklist).subscribe((data) => {
      this.router.navigate(['/']);
    });
  }
  title = 'checklistmanager.client';
}
