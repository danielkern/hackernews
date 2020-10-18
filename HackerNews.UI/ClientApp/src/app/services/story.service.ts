import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Story } from '../models/story.model';
import { StoryTypes } from '../models/storyTypesEnum.model';

@Injectable({
  providedIn: 'root',
})
export class StoryService {
  constructor(private http: HttpClient) {
  }

  private baseUrl: string = 'https://localhost:44377';

  get(storyType: StoryTypes, lastItemId: number = 0, pageSize: number) {
    return this.http.get<Story[]>(`${this.baseUrl}/api/story?storyType=${storyType}&lastItemId=${lastItemId}&size=${pageSize}`);
  }

  //getConfigResponse(): Observable<HttpResponse<Config>> {
  //  return this.http.get<Config>(
  //    this.configUrl, { observe: 'response' });
  //}

  getById(id: number) {
    return this.http.get<Story>(`${this.baseUrl}/api/story/${id}`);
  }

  search() {
    return null;
  }

  create() {
    throw new Error('Not implemented');
  }

  update() {
    throw new Error('Not implemented');
  }

  delete() {
    throw new Error('Not implemented');
  }
}
