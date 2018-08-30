import { Component, OnInit } from '@angular/core';
import { PackageService } from '../../shared/services/package.service';

@Component({
  selector: 'app-package',
  templateUrl: './package.component.html',
  styleUrls: ['./package.component.css']
})
export class PackageComponent implements OnInit {

  constructor(private packageService:PackageService) { }

  ngOnInit() {
  }

  onKeyUp(value) {

    console.log(value)
    this.packageService.subject
    .next(value);
  }
}
