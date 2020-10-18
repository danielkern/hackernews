import { AppPage } from './app.po';
import { element, by } from 'protractor';

describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getMainHeading()).toEqual('Hello, world!');
  });
});

describe('Stories Component', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  xit('should display "Jobs Stories" as title', () => {
    page.navigateToUrl('/stories/jobs');
    expect(page.getMainHeading()).toEqual('Jobs Stories');
  });

  it('should display "New Stories" as title', async () => {
    await page.navigateToUrl('/stories/new');
   
    expect(await page.getMainHeading()).toEqual('New Stories');

    var stories = element.all(by.css('.story-row'));
    expect(stories.count()).toBeGreaterThan(0);

    await page.waitForElementByCSS('.page-size-25', 60000)
    await page.waitForElementByCSS('.btn-load-more', 60000);
      
    expect(await page.getPageSizeValue()).toBe('25');

    page.clickLoadMore().then(() => {
      expect(page.getLoadMoreButton().isPresent()).toBe(true);
    });
  }, 120000);

  //it('should disable button during loading', () => {
    
  //});

  //it('should have page size as 25 by default', () => {
    
  //});
});
