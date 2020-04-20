import { Component } from '@angular/core';
import { MobileItemService } from '../mobile-item.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css']
})
export class CounterComponent {
  public currentCount = 0;
  public Data = [];

  constructor(
    private _mobileItemService: MobileItemService,
  ) {

  }

  ngOnInit() {
    this.GetData();
  }

  GetData() {
    this._mobileItemService
      .GetMobileItem()
      .subscribe(
        res => {
          this.Data = res;
          console.log(res);
        },

      );
  }





}
