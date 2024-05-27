import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../../models/vehicle.model';
import { Response } from '../../../models/response.model';

@Component({
  selector: 'app-add-checklist',
  templateUrl: './add-checklist.component.html',
  styleUrl: './add-checklist.component.css'
})
export class AddChecklistComponent {
  constructor(private http: HttpClient) { }



}
