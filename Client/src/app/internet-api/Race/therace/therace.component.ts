import { Component, OnInit } from '@angular/core';
import { TheRace } from '../../OnlineAPI';
import * as _ from 'lodash';
import { InternetAPIComponent } from '../../internet-api.component';

@Component({
  selector: 'app-therace',
  templateUrl: './therace.component.html',
  styleUrls: ['./therace.component.css']
})
export class TheraceComponent implements OnInit {

  constructor(private InternetAPIComponent: InternetAPIComponent) { }
  private _search: string = "";
  ngOnInit() {
  }
  

  get SearchRace() {
    return this._search;
  }
  set SearchRace(value: string) {
    this._search = value.toLowerCase();
    if(this._search != "") {
     this.InternetAPIComponent.setFieldsRace(this._search)
      };
    }
  }

