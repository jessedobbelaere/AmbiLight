//
//  SecondViewController.h
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 20/05/12.
//  Copyright (c) 2012. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface SecondViewController : UIViewController
@property (weak, nonatomic) IBOutlet UITextField *ipAdresInput;
@property (weak, nonatomic) IBOutlet UILabel *errorLabel;
@property (weak, nonatomic) IBOutlet UIButton *connectButton;

-(IBAction)ConnectPressed:(id)sender;

// Textbox controls
- (IBAction)textFieldReturn:(id)sender;
- (IBAction)backgroundTouched:(id)sender;

@end
