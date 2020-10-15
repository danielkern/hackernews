import { AppPage } from './app.po';

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

describe('News', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display "News" as title', () => {
    page.navigateToUrl('/stories/new');
    expect(page.getMainHeading()).toEqual('New');
  });

  it('should display "Jobs" as title', () => {
    page.navigateToUrl('/stories/jobs');
    expect(page.getMainHeading()).toEqual('Jobs');
  });

  it('should disable button during loading', () => {
    page.clickLoadMore();
    expect(page.getLoadMoreButton()).toBe('disabled');
  });

  it('should have page size as 25 by default', () => {
    expect(page.getPageSizeValue()).toBe('25');
  });
});
