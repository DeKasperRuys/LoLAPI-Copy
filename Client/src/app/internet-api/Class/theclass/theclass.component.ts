import { Component, OnInit } from '@angular/core';
import { TheClass } from '../../OnlineAPI';
import * as _ from 'lodash';
import { InternetAPIComponent } from '../../internet-api.component';

@Component({
  selector: 'app-theclass',
  templateUrl: './theclass.component.html',
  styleUrls: ['./theclass.component.css']
})
export class TheclassComponent implements OnInit {

  constructor(private InternetAPIComponent: InternetAPIComponent) { }
  private _search: string = "";
  ngOnInit() {
  }


  get SearchClass() {
    return this._search;
  }
  set SearchClass(value: string) {
    this._search = value.toLowerCase();
  //this._search = "haha"
    if(this._search != "") {
    this.InternetAPIComponent.setFieldsClass(this._search)
      };
    }
  }



