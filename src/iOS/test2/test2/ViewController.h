//
//  ViewController.h
//  test2
//
//  Created by Jesse Dobbelaere on 29/03/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ViewController : UIViewController <NSStreamDelegate>
@property (weak, nonatomic) IBOutlet UITextField *inputNameField;
@property (weak, nonatomic) IBOutlet UIView *joinView;
- (IBAction)joinChat:(id)sender;

@end

NSInputStream *inputStream;
NSOutputStream *outputStream;