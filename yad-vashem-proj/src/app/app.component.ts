import { Component } from '@angular/core';
import { TableComponent } from './table/table.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { RestApiService } from './services/http.service';

@Component({
  providers:  [TableComponent,AppHeaderComponent],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public restApi: RestApiService){}
  title = 'yad-vashem-proj';
  dataToTable =[];
  data =   this.restApi.getData().subscribe((data: any) => {
    this.dataToTable=data
  });
}
