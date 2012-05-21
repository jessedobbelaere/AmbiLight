//
//  SecondViewController.h
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 15/04/12.
//  Copyright (c) 2012 Dobbelaere Auto-Elektriciteit. All rights reserved.
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
