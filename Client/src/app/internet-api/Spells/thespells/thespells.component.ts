import { Component, OnInit } from '@angular/core';
import { TheSpell } from '../../OnlineAPI';
import * as _ from 'lodash';
import { InternetAPIComponent } from '../../internet-api.component';


@Component({
  selector: 'app-thespells',
  templateUrl: './thespells.component.html',
  styleUrls: ['./thespells.component.css']
})
export class ThespellsComponent implements OnInit {


  constructor(private InternetAPIComponent: InternetAPIComponent) { }
  private _search: string = "";
  ngOnInit() {
  }
  

  get SearchSpell() {
    return this._search;
  }
  set SearchSpell(value: string) {
    this._search = value.toLowerCase();
    if(this._search != "") {
     this.InternetAPIComponent.setFieldsSpell(this._search)
      };
    }
  }

