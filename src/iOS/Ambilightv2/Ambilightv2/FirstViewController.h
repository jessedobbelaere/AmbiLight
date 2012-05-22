//
//  FirstViewController.h
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 15/04/12.
//  Copyright (c) 2012 Dobbelaere Auto-Elektriciteit. All rights reserved.
//

#import <UIKit/UIKit.h>

@class AmbiConnection;
@interface FirstViewController : UIViewController

// Properties
@property (weak, nonatomic) IBOutlet UIButton *StartButton;
@property (weak, nonatomic) IBOutlet UIButton *StopButton;
@property (weak, nonatomic) IBOutlet UILabel *ErrorLabel;
@property (weak, nonatomic) IBOutlet UISegmentedControl *SegmentFxBtn;
@property (weak, nonatomic) IBOutlet UIButton *StopFxBtn;


// Methoden
- (IBAction)StartAmbilight:(id)sender;
- (IBAction)StopAmbilight:(id)sender;
- (IBAction)startFx:(id)sender;
- (IBAction)stopFx:(id)sender;

@end

