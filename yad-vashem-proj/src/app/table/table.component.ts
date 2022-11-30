import { Component, Input } from '@angular/core';

export interface InstitutionData {
  institution: string;
  phone: string;
  address: string;
  city: string;
  institutionKind: string;
  age: string;
  symbol: string;
  code: string;
  addOrder: string;
}
@Component({
  selector: 'tableData',
  templateUrl: './table.component.html',
  styleUrls: ['table.component.css'],
})
//TODO : change type to InstitutionData
export class TableComponent {
  @Input() item: any = [];
}
