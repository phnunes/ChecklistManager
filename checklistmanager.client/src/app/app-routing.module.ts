import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddChecklistComponent } from './checklists/add-checklist/add-checklist.component';

const routes: Routes = [
  {
    path: 'checklist',
    redirectTo: 'https://localhost:7228/Checklist'
  },
  {
    path: 'new-checklist',
    component: AddChecklistComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash : true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
