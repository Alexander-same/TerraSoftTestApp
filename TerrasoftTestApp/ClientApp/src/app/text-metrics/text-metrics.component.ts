import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators  } from '@angular/forms';
import { TextRequest } from '../models/text-request.model';
import { TextResponse } from '../models/text-response.model';
import { ApiService } from '../services/api-service';

@Component({
  selector: 'app-text-metrics',
  templateUrl: './text-metrics.component.html'
})
export class TextMetricsComponent implements OnInit{
  textAndTypeForm: FormGroup;
  metricTypes: string[] = [];
  selectedType: string;


  textResult: TextResponse;

  constructor(private apiService: ApiService, private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.apiService.getTypes().subscribe(data => {
      this.metricTypes = data;

      this.textAndTypeForm = this.fb.group({
        metricType: [this.metricTypes[0]],
        text: ['']
      });
    });
  }

  submit() {
    
    const requestData: TextRequest = {
      text: this.textAndTypeForm.get('text').value,
      metricType: this.textAndTypeForm.get('metricType').value
    }

    this.apiService.sendText(requestData).subscribe(data =>
      this.textResult = data);
  }
}
